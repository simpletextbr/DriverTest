import { useEffect } from "react";
import { GetAllDrivers } from "../../../core/api/DriverManagement/DriverManagment";

export default function HomePage(): JSX.Element {
  useEffect(() => {
    async function loadData() {
      await GetAllDrivers().then((res) => res.items);
    }

    loadData();
  }, []);

  return (
    <div>
      <h1>Home Page</h1>
    </div>
  );
}
