import React from "react";
import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import "@testing-library/jest-dom";
import DefaultLocationButton from "../components/DefaultLocationButton";

describe("DefaultLocationButton", () => {
  test("calls setDefaultCity with cityName on button click", async () => {
    const mockSetDefaultCity = jest.fn();
    const cityName = "London";

    render(
      <DefaultLocationButton
        cityName={cityName}
        setDefaultCity={mockSetDefaultCity}
      />
    );

    const button = screen.getByRole("button", { name: /set as default city/i });
    await userEvent.click(button);

    expect(mockSetDefaultCity).toHaveBeenCalledWith(cityName);
  });
});
