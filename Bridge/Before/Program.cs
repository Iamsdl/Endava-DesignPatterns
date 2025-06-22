using Before.Devices;
using Before.Drivers;
using DBModel;

{
    DeviceDriver tensiometer = new SerialTensiometerDriver("TestSerialTens", "COM3");

    tensiometer.InitialiseDevice();
    Console.WriteLine($"Is functional: {tensiometer.IsFunctional()}");

    List<Measurement> measurements = tensiometer.StartMeasurement();
    foreach (var measurement in measurements)
    {
        Console.WriteLine($"Measurement: {measurement.MeasurementType} - {measurement.Value} {measurement.Unit}");
    }
}
Console.WriteLine();
{
    DeviceDriver tensiometer = new DLLTensiometerDriver("TestDLLTens");

    tensiometer.InitialiseDevice();
    Console.WriteLine($"Is functional: {tensiometer.IsFunctional()}");

    List<Measurement> measurements = tensiometer.StartMeasurement();
    foreach (var measurement in measurements)
    {
        Console.WriteLine($"Measurement: {measurement.MeasurementType} - {measurement.Value} {measurement.Unit}");
    }
}