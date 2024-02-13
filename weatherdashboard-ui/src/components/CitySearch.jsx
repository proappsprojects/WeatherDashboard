import React, { useState, useEffect, useCallback } from "react";
import axios from "axios";

import { debounce } from "lodash";
import DefaultLocationButton from "./DefaultLocationButton";

const CitySearch = ({ onSearchChange }) => {
  const [cityName, setCityName] = useState(
    localStorage.getItem("defaultCity") || "London"
  );
  const REACT_APP_WEATHER_API = process.env.REACT_APP_WEATHER_API;

  const fetchWeather = useCallback(
    debounce((searchTerm) => {
      const url = `${REACT_APP_WEATHER_API}${searchTerm}`;
      axios
        .get(url)
        .then((response) => {
          onSearchChange(response.data);
        })
        .catch((error) => {
          if (!axios.isCancel(error)) {
            console.error("Error:", error);
            onSearchChange(null);
          }
        });
    }, 1000),
    []
  );

  const setDefaultCity = (city) => {
    localStorage.setItem("defaultCity", city);
  };

  useEffect(() => {
    if (cityName !== "") {
      fetchWeather(cityName);
    } else {
      onSearchChange(null); // Clear weather data when input is cleared
    }
    // Cleanup function to cancel the debounced call if the component unmounts
    return () => {
      fetchWeather.cancel();
    };
  }, [cityName, fetchWeather]); // Effect depends on cityName and the memoized fetchWeather function

  const handleChange = (event) => {
    if (event.target.value === "") {
      onSearchChange(null);
    }
    setCityName(event.target.value);
  };

  return (
    <div className="input-group card-body p-3">
      <input
        type="text"
        value={cityName}
        onChange={handleChange}
        placeholder="Enter City"
      />
      <DefaultLocationButton
        cityName={cityName}
        setDefaultCity={setDefaultCity}
      ></DefaultLocationButton>
    </div>
  );
};
export default CitySearch;
