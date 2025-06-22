using After.Communicator;
using After.Drivers;
using DBModel;

{
    var tensiometer = new TensiometerDriver("TensoSerial", new SerialCommunicator("COM3"));

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
    var tensiometer = new TensiometerDriver("TensoDLL", new DLLCommunicator());

    tensiometer.InitialiseDevice();
    Console.WriteLine($"Is functional: {tensiometer.IsFunctional()}");

    List<Measurement> measurements = tensiometer.StartMeasurement();
    foreach (var measurement in measurements)
    {
        Console.WriteLine($"Measurement: {measurement.MeasurementType} - {measurement.Value} {measurement.Unit}");
    }
}