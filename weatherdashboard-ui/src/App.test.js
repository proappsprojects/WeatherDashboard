import { render, screen } from "@testing-library/react";
import Dashboard from "./components/Dashboard/Dashboard";

test("renders learn react link", () => {
  render(<Dashboard />);
  const dashboardComponent = screen.getByText(/dashboard/i);
  expect(dashboardComponent).toBeInTheDocument();
});
