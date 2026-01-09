using api.Models;
using Facet;

namespace api.DTOs
{
    [Facet(typeof(TaskModel), exclude: 
        [
            nameof(TaskModel.BaseUrl), 
            nameof(TaskModel.PrimaryKey),
            nameof(TaskModel.RequestClientOptions),
            nameof(TaskModel.TableName)
        ]
    )]
    public partial record TaskDto;
}
