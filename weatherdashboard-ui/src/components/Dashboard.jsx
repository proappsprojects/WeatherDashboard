import React, { useState } from "react";
import Header from "./Header";
import CitySearch from "./CitySearch";
import useProperCase from "../customHooks/useProperCase";

export default function Dashboard() {
  const [data, setData] = useState({});
  const toProperCase = useProperCase();
  const REACT_APP_ICON_URL = process.env.REACT_APP_ICON_URL;

  const iconCode = data?.weather?.[0]?.icon;

  const iconUrl = iconCode ? `${REACT_APP_ICON_URL}${iconCode}.png` : "";

  const handleChange = (searchData) => {
    setData(searchData);
  };

  return (
    <section className="vh-100" style={{ color: "#4B515D" }}>
      <div className="container">
        <div className="row d-flex justify-content-center align-items-center h-100">
          <div className="card col-md-8 col-lg-6 col-xl-4">
            <Header />
            <CitySearch onSearchChange={handleChange} />
            <div>
              <div className="card-body p-4">
                <h4 className="mb-1 sfw-normal">
                  <strong> {data?.name}</strong>
                </h4>
                <p className="mb-2">
                  Country: <strong> {data?.sys?.country}</strong>
                </p>

                <p className="mb-2">
                  Current temperature:{" "}
                  <strong> {data?.main?.temp?.toFixed()}°F</strong>
                </p>
                <p>
                  Humidity:{" "}
                  <strong className="bold">{data?.main?.humidity}%</strong>
                </p>
                <p>
                  Wind Speed:{" "}
                  <strong>{data?.wind?.speed?.toFixed()} mph</strong>
                </p>
                <div className="d-flex flex-row align-items-center">
                  <p className="mb-0 me-4">
                    <strong>
                      {toProperCase(data?.weather?.[0]?.description)}
                    </strong>
                  </p>
                  {iconUrl && (
                    <div>
                      <img src={iconUrl} alt="Weather icon" />
                    </div>
                  )}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}
