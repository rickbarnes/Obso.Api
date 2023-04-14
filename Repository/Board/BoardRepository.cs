using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Domain.Board;
using IRepository.Boards;
using Microsoft.Extensions.Configuration;

namespace Repository.Board;

public sealed class BoardRepository : BaseRepository, IBoardRepository
{
    private readonly string _tableName = "Obso-Production";

    public BoardRepository(IConfiguration configuration)
        : base(configuration)
    {
    }

    public async Task<BoardEntity?> GetBoardById(Guid tenantId, Guid boardId)
    {
        Dictionary<string, AttributeValue>? lastEvaluatedKey = null;

        var values = new Dictionary<string, AttributeValue>
        {
            {
                ":v_PK", new AttributeValue
                {
                    S = "Board"
                }
            },
            {
                ":v_SK", new AttributeValue
                {
                    S = this.BuildSK(tenantId, boardId)
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
                return this.MapBoard(response.Items.First());
            }

        } while (lastEvaluatedKey != null && lastEvaluatedKey.Count > 0);

        return null;
    }

    public async Task Add(BoardEntity boardEntity)
    {
        var table = Table.LoadTable(this.Client, this._tableName, DynamoDBEntryConversion.V2);

        var board = new Document();

        board["PK"] = "Board";
        board["SK"] = this.BuildSK(boardEntity.TenantId, boardEntity.BoardId);
        board["Name"] = boardEntity.Name;

        await table.PutItemAsync(board);
    }

    public async Task Update(BoardEntity boardEntity)
    {
        var table = Table.LoadTable(this.Client, this._tableName, DynamoDBEntryConversion.V2);

        var board = new Document();

        board["PK"] = "Board";
        board["SK"] = this.BuildSK(boardEntity.TenantId, boardEntity.BoardId);
        board["OwnerId"] = Guid.NewGuid();

        await table.UpdateItemAsync(board);
    }


    private string BuildSK(Guid tenantId, Guid boardId)
    {
        return $"Tenant#{tenantId}#Board#{boardId}";
    }

    private BoardEntity MapBoard(Dictionary<string, AttributeValue> item)
    {
        var splitSK = item["SK"].S.Split("#");

        return new BoardEntity
        {
            BoardId = Guid.Parse(splitSK[3]),
            Name = item["Name"].S,
            TenantId = Guid.Parse(splitSK[1])
        };
    }
}