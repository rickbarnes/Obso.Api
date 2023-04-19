using Amazon.DynamoDBv2.Model;
using Domain.Board;
using Domain.Column;
using IRepository.Column;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Column
{
    public sealed class ColumnRepository : BaseRepository, IColumnRepository
    {
        private readonly string _tableName = "Obso-Production";

        public ColumnRepository(IConfiguration configuration)
            : base(configuration)
        {
        }

        public async Task<ColumnEntity?> GetColumnById(Guid columnId, Guid boardId)
        {
            Dictionary<string, AttributeValue>? lastEvaluatedKey = null;

            var values = new Dictionary<string, AttributeValue>
            {
                {
                    ":v_PK", new AttributeValue
                    {
                        S = "Column"
                    }
                },
                {
                    ":v_SK", new AttributeValue
                    {
                        S = this.BuildSK(columnId, boardId)
                    }
                },
            };

            do
            {
                var request = new QueryRequest
                {
                    TableName = "Obso-Production",
                    KeyConditionExpression = "PK = :v_PK and SK = :v_SK",
                    ExpressionAttributeValues = values,
                    ExclusiveStartKey = lastEvaluatedKey
                };


                var response = await this.Client.QueryAsync(request);

                if (response.Items.Count != 0)
                {
                    return this.MapColumn(response.Items.First());
                }

            } while (lastEvaluatedKey != null && lastEvaluatedKey.Count > 0);

            return null;
        }

        private string BuildSK(Guid columnId, Guid boardId)
        {
            return $"Board#{boardId}#Column#{columnId}";
        }

        private ColumnEntity MapColumn(Dictionary<string, AttributeValue> item)
        {
            var splitSK = item["SK"].S.Split("#");

            return new ColumnEntity
            {
                Id = Guid.Parse(splitSK[3]),
                Name = item["Name"].S,
                Header = item["Header"].S,
                BoardId = Guid.Parse(splitSK[1])
            };
        }
    }
}
