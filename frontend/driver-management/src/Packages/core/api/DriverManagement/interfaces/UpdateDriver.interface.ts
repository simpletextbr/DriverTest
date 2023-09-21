export interface UpdateDriverInput {
  id: string;
  name: string;
  dateOfBirth: Date;
  drivingLicenseNumber: string;
  drivingLicenseExpirationDate: Date;
  email: string;
  city: string;
}

export interface UpdateDriverOutput {
  id: string;
  name: string;
  dateOfBirth: Date;
  drivingLicenseNumber: string;
  drivingLicenseExpirationDate: Date;
  email: string;
  city: string;
}
