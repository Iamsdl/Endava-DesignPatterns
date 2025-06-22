namespace DBModel
{
    public class Measurement
    {
        public Guid Id { get; set; }
        public MeasurementCategoryEnum MeasurementCategory { get; set; }
        public MeasurementTypeEnum MeasurementType { get; set; }
        public MeasurementSideEnum MeasurementSide { get; set; }

        public double Value { get; set; }
        public string Unit { get; set; }
    }
}
