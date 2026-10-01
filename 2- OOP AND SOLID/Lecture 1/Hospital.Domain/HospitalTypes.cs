namespace HospitalDomain;

public class Doctor
{
    public string Name;
    public string Specialty;
}

public class Patient
{
    public string Name;
    public int Age;
    public Doctor AssignedDoctor;
}

public class Room
{
    public int Number;
    public bool IsOccupied;
    public Patient Current;
}

public class Hospital
{
    public List<Doctor> Doctors = new List<Doctor>();
    public List<Room> Rooms = new List<Room>();

    public void Admit(Patient p, Room room)
    {
        if (room.IsOccupied)
        {
            throw new InvalidOperationException($"Room {room.Number} is already occupied.");
        }

        room.Current = p;
        room.IsOccupied = true;
    }

    public void AssignDoctor(Patient p, Doctor d)
    {
        p.AssignedDoctor = d;
    }
}
