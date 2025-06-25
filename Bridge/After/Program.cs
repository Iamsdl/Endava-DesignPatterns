using After.Communicator;
using After.Drivers;
using DBModel;

{
    DeviceDriver tensiometer = new TensiometerDriver("TestSerialTensiometer", new SerialCommunicator("COM3"));

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
    DeviceDriver tensiometer = new TensiometerDriver("TestUsbTensiometer", new UsbCommunicator(0x0A5C, 0x5843));

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
    DeviceDriver thermometer = new ThermometerDriver("TestSerialThermometer", new SerialCommunicator("COM3"));

    thermometer.InitialiseDevice();
    Console.WriteLine($"Is functional: {thermometer.IsFunctional()}");

    List<Measurement> measurements = thermometer.StartMeasurement();
    foreach (var measurement in measurements)
    {
        Console.WriteLine($"Measurement: {measurement.MeasurementCategory} - {measurement.Value} {measurement.Unit}");
    }
}
Console.WriteLine();
{
    DeviceDriver thermometer = new ThermometerDriver("TestUsbThermometer", new UsbCommunicator(0x0A5C, 0x5844));

    thermometer.InitialiseDevice();
    Console.WriteLine($"Is functional: {thermometer.IsFunctional()}");

    List<Measurement> measurements = thermometer.StartMeasurement();
    foreach (var measurement in measurements)
    {
        Console.WriteLine($"Measurement: {measurement.MeasurementCategory} - {measurement.Value} {measurement.Unit}");
    }
}