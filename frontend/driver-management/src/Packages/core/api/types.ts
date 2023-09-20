export interface List<T> {
  items: T[];
  totalCount: number;
}

export interface Driver {
  id: number;
  name: string;
  dateOfBirth: Date;
  drivingLicenseNumber: string;
  drivingLicenseExpirationDate: Date;
  email: string;
  city: string;
}
