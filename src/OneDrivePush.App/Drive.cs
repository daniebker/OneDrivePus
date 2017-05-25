namespace OneDrivePush.App
{
    public class Drive
    {
        public string Id { get; set; }
        public string DriveType { get; set; }
        public DriveUser Owner { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null 
                || obj.GetType() != typeof(Drive))
            {
                return false;
            }

            Drive other = obj as Drive;

            if(other.Id != this.Id)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}