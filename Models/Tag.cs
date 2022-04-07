using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Tag> SenhaTag { get; set; }

        public Tag() { }

        public Tag(
            string Descricao
        )
        {
            this.Descricao = Descricao;

            Context db = new Context();
            db.Tags.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ---------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Descricao: {this.Descricao}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Tag.ReferenceEquals(this, obj))
            {
                return false;
            }
            Tag it = (Tag) obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static void AlterarTag(
            int Id,
            string Descricao
        )
        {
            Tag tag = GetTag(Id);
            tag.Descricao = Descricao;

            Context db = new Context();
            db.Tags.Update(tag);
            db.SaveChanges();
        }


        public static IEnumerable<Tag> GetTags()
        {
            Context db = new Context();
            return (from Tag in db.Tags select Tag);
        }

        public static Tag GetTag(int Id)
        {
            Context db = new Context();
            IEnumerable<Tag> tags = from Tag in db.Tags
                            where Tag.Id == Id
                            select Tag;

            return tags.First();
        }

        public static void RemoverTag(Tag tag)
        {
            Context db = new Context();
            db.Tags.Remove(tag);
            db.SaveChanges();
        }
    }
}