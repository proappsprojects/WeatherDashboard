import React from "react";
import { render, screen } from "@testing-library/react";
import "@testing-library/jest-dom";
import Header from "../components/Header";

describe("Header Component", () => {
  test("renders correct header text", () => {
    render(<Header />);
    const headingElement = screen.getByRole("heading", {
      name: /weather dashboard/i,
    });
    expect(headingElement).toBeInTheDocument();
  });
});
