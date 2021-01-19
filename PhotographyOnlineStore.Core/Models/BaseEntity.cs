using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyOnlineStore.Core.Models
{
    public abstract class BaseEntity
    {
        public String Id { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreateAt = DateTime.Now;

        }


    }
}