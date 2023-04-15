using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;

namespace Repository;

public abstract class BaseRepository
{
    private readonly IConfiguration _configuration;

    internal BaseRepository(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    protected AmazonDynamoDBClient Client
    {
        get
        {

             var credentials = new BasicAWSCredentials(this._configuration["AWS:AccessKey"], this._configuration["AWS:SecretKey"]);

            return new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
        }
    }
}
