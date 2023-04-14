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
            var credentials = new BasicAWSCredentials("AKIARMF6AUE5V75OYK6U", "pbzKuihv2/l5E1Y9uvj4gJ5It7rGPouHWtSntSzO");
            // var credentials = new BasicAWSCredentials(this._configuration["AWS:AccessKey"], this._configuration["AWS:SecretKey"]);

            return new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
        }
    }
}