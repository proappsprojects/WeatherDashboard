import React from "react";
import { render, screen } from "@testing-library/react";
import "@testing-library/jest-dom";
import CitySearch from "../components/CitySearch";

describe("CitySearch Component", () => {
  test("input for entering city exists", () => {
    render(<CitySearch />); // Render the component

    // Find the input element
    const inputElement = screen.getByPlaceholderText("Enter City");

    // Assert the input element is in the document
    expect(inputElement).toBeInTheDocument();

    // Additionally, you can check if the input type is "text"
    expect(inputElement).toHaveAttribute("type", "text");
  });
});
