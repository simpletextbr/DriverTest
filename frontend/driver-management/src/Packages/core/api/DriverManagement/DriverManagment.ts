import api from "../api";
import { GetAllDriversOutput } from "./interfaces/GetAllDrivers.interface";
import { List } from "./../types";
import {
  GetDriverByIdInput,
  GetDriverByIdOutput,
} from "./interfaces/GetDriverById.interface";
import {
  CreateDriverInput,
  CreateDriverOutput,
} from "./interfaces/CreateDriver.interface";
import {
  UpdateDriverInput,
  UpdateDriverOutput,
} from "./interfaces/UpdateDriver.interface";
import { DeleteDriverInput } from "./interfaces/DeleteDriver.interface";

async function GetAllDrivers(): Promise<List<GetAllDriversOutput>> {
  const response = await api.get("api/DriverManagement/drivers");

  const drivers: List<GetAllDriversOutput> = {
    items: response.data.items,
    totalCount: response.data.length,
  };

  return drivers;
}

async function GetDriverById(
  input: GetDriverByIdInput
): Promise<GetDriverByIdOutput> {
  const response = await api.get(`api/DriverManagement/drivers/${input.id}`);

  const driver: GetDriverByIdOutput = {
    id: response.data,
    name: response.data.name,
    dateOfBirth: response.data.dateOfBirth,
    drivingLicenseNumber: response.data.drivingLicenseNumber,
    drivingLicenseExpirationDate: response.data.drivingLicenseExpirationDate,
    email: response.data.email,
    city: response.data.city,
  };

  return driver;
}

async function CreateDriver(
  input: CreateDriverInput
): Promise<CreateDriverOutput> {
  const response = await api.post("api/DriverManagement/drivers", input);

  const driver: CreateDriverOutput = {
    id: response.data,
    name: response.data.name,
    dateOfBirth: response.data.dateOfBirth,
    drivingLicenseNumber: response.data.drivingLicenseNumber,
    drivingLicenseExpirationDate: response.data.drivingLicenseExpirationDate,
    email: response.data.email,
    city: response.data.city,
  };

  return driver;
}

async function UpdateDriver(
  input: UpdateDriverInput
): Promise<UpdateDriverOutput> {
  const response = await api.put("api/DriverManagement/drivers", input);

  const driver: UpdateDriverOutput = {
    id: response.data,
    name: response.data.name,
    dateOfBirth: response.data.dateOfBirth,
    drivingLicenseNumber: response.data.drivingLicenseNumber,
    drivingLicenseExpirationDate: response.data.drivingLicenseExpirationDate,
    email: response.data.email,
    city: response.data.city,
  };

  return driver;
}

async function DeleteDriver(input: DeleteDriverInput): Promise<void> {
  await api.delete(`api/DriverManagement/drivers/${input.id}`);
}

export {
  GetAllDrivers,
  GetDriverById,
  CreateDriver,
  UpdateDriver,
  DeleteDriver,
};
