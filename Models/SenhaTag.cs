using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Models
{
    public class SenhaTag
    {
        public int Id { get; set; }
        public int SenhaId { get; set; }
        public Senha Senha { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        

        public SenhaTag() { }

        public SenhaTag(
            int SenhaId,
            int TagId
        )
        {
            this.SenhaId = SenhaId;
            this.TagId = TagId;

            Context db = new Context();
            db.SenhaTags.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ---------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n SenhaId: {this.SenhaId}"
                + $"\n TagId: {this.TagId}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!SenhaTag.ReferenceEquals(this, obj))
            {
                return false;
            }
            SenhaTag it = (SenhaTag) obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static IEnumerable<SenhaTag> GetSenhaTags()
        {
            Context db = new Context();
            return (from SenhaTag in db.SenhaTags select SenhaTag);
        }

        public static SenhaTag GetSenhaTag(
            int SenhaId,
            int TagId
        )
        {
            Context db = new Context();
            IEnumerable<SenhaTag> senhaTags = from SenhaTag in db.SenhaTags
                            where SenhaTag.SenhaId == SenhaId && SenhaTag.TagId == TagId
                            select SenhaTag;

            return senhaTags.First();
        }

        public static SenhaTag GetById(int Id)
        {
            Context db = new Context();
            IEnumerable<SenhaTag> senhaTags = from SenhaTag in db.SenhaTags
                            where SenhaTag.Id == Id
                            select SenhaTag;

            return senhaTags.First();
        }

        public static IEnumerable<SenhaTag> GetBySenhaId(int SenhaId)
        {
            Context db = new Context();
            return (from SenhaTag in db.SenhaTags
                            where SenhaTag.SenhaId == SenhaId
                            select SenhaTag);
        }

        public static void RemoverSenhaTag(SenhaTag tag)
        {
            Context db = new Context();
            db.SenhaTags.Remove(tag);
            db.SaveChanges();
        }
    }
}