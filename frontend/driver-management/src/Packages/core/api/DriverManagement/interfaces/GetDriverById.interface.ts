export interface GetDriverByIdInput {
  id: string;
}

export interface GetDriverByIdOutput {
  id: number;
  name: string;
  dateOfBirth: Date;
  drivingLicenseNumber: string;
  drivingLicenseExpirationDate: Date;
  email: string;
  city: string;
}
