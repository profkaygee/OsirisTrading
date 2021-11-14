export interface Vehicle {
    id: number;
    uid: string;
    vin: string;
    make_and_model: string;
    color: string;
    transmission: string;
    drive_type: string;
    fuel_type: string;
    car_type: string;
    car_options: string[];
    specs: string[];
    doors: number;
    mileage: number;
    kilometrage: number;
    license_plate: string;
}