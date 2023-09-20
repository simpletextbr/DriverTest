export interface CreateDriverInput {
  name: string;
  dateOfBirth: Date;
  drivingLicenseNumber: string;
  drivingLicenseExpirationDate: Date;
  email: string;
  city: string;
}

export interface CreateDriverOutput {
  id: string;
  name: string;
  dateOfBirth: Date;
  drivingLicenseNumber: string;
  drivingLicenseExpirationDate: Date;
  email: string;
  city: string;
}
