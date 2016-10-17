namespace FurnitureDesignArchive.Models
{
    public class FurniturePart
    {
        public int FurniturePartId { get; set; }
        public string PartName { get; set; }
        public int PartCount { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double BoardThickness { get; set; }
        public double partBoardFoot { get; set; }
        public string PartNotes { get; set; }
        public string PartImgUrl { get; set; }
    }
}