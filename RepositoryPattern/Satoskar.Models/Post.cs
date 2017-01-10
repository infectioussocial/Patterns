

namespace Satoskar.Models
{
    public class Post : IEntity
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        #region IEntity Members

        public int Id { get; set; }

        #endregion
    }
}
