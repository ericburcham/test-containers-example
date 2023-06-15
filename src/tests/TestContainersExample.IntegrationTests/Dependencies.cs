using System.Collections.Generic;
using DotNet.Testcontainers.Containers;
using Testcontainers.Elasticsearch;
using Testcontainers.MariaDb;
using Testcontainers.MsSql;
using Testcontainers.MySql;
using Testcontainers.Oracle;
using Testcontainers.PostgreSql;

namespace TestContainersExample.IntegrationTests;

internal sealed class Dependencies : Singleton<Dependencies>, IProvideContainers
{
    private Dependencies()
    {
        ElasticSearch = new ElasticsearchBuilder().WithImage(Constants.ELASTIC_SEARCH_IMAGE).Build();
        MariaDb = new MariaDbBuilder().WithImage(Constants.MARIA_DB_IMAGE).Build();
        MySql = new MySqlBuilder().WithImage(Constants.MY_SQL_IMAGE).Build();
        Oracle = new OracleBuilder().WithImage(Constants.ORACLE_IMAGE).Build();
        Postgres = new PostgreSqlBuilder().WithImage(Constants.POSTGRES_IMAGE).Build();
        SqlServer = new MsSqlBuilder().WithImage(Constants.SQL_SERVER_IMAGE).Build();
    }

    public ElasticsearchContainer ElasticSearch { get; }

    public MariaDbContainer MariaDb { get; }

    public MySqlContainer MySql { get; }

    public OracleContainer Oracle { get; }

    public PostgreSqlContainer Postgres { get; }

    public MsSqlContainer SqlServer { get; }

    public IEnumerable<IContainer> Containers
    {
        get
        {
            yield return ElasticSearch;
            yield return MariaDb;
            yield return MySql;
            yield return Oracle;
            yield return Postgres;
            yield return SqlServer;
        }
    }
}