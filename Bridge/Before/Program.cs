using Before.Devices;
using Before.Drivers;
using DBModel;

{
    DeviceDriver tensiometer = new SerialTensiometerDriver("TestSerialTensiometer", "COM3");

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
    DeviceDriver tensiometer = new UsbTensiometerDriver("TestUsbTensiometer", 0x0A5C, 0x5843);

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
    DeviceDriver thermometer = new SerialThermometerDriver("TestSerialThermometer", "COM3");

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
    DeviceDriver thermometer = new UsbThermometerDriver("TestUsbThermometer", 0x0A5C, 0x5843);

    thermometer.InitialiseDevice();
    Console.WriteLine($"Is functional: {thermometer.IsFunctional()}");

    List<Measurement> measurements = thermometer.StartMeasurement();

    foreach (var measurement in measurements)
    {
        Console.WriteLine($"Measurement: {measurement.MeasurementCategory} - {measurement.Value} {measurement.Unit}");
    }
}