using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Services.AttributeGroup
{
    public interface IAttributeGroupService
    {
        Task<List<Model.DTO.AttributeGroup>?> GetAttributeGroups(int page, int pageSize, string isoCode);
        Task<List<Model.DTO.AttributeGroup>?> GetAllAttributeGroupsWithPagination(string isoCode);
    }
}
