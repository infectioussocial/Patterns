using System.Collections.Generic;

namespace Satoskar.Models
{
    public class Blog : IEntity
    {

        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }

        #region IEntity Members

        public int Id { get; set; }

        #endregion

    }
}
