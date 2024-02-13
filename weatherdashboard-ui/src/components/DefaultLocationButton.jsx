// SetDefaultCityButton.js
import React from "react";

const DefaultLocationButton = ({ cityName, setDefaultCity }) => {
  return (
    <button
      onClick={() => setDefaultCity(cityName)}
      className="btn btn-primary btn-sm"
    >
      Set as Default City
    </button>
  );
};

export default DefaultLocationButton;
