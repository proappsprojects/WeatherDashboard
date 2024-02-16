import React, { useState } from "react";
import Header from "../Header";
import CitySearch from "../CitySearch";
import useProperCase from "../../customHooks/useProperCase";
import styles from "./Dashboard.module.css";

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
    <section className={`${styles.backgroundColor} vh-100`}>
      <div className="container">
        <div className="row d-flex justify-content-center align-items-center h-100">
          <div
            className={`${styles.cardBackgroundColor} card col-md-8 col-lg-6 col-xl-4`}
          >
            <Header />
            <CitySearch onSearchChange={handleChange} />
            <div>
              <div className="card-body p-3">
                <h4 className="mb-2">
                  <strong> {data?.name}</strong>
                </h4>
                <p className="mb-2">
                  Country: <strong> {data?.sys?.country}</strong>
                </p>

                <p className="mb-2">
                  Current temperature:{" "}
                  <strong> {data?.main?.temp?.toFixed()}°C</strong>
                </p>
                <p className="mb-2">
                  Humidity:{" "}
                  <strong className="bold">{data?.main?.humidity}%</strong>
                </p>
                <p className="mb-2">
                  Wind Speed:{" "}
                  <strong>{data?.wind?.speed?.toFixed()} mph</strong>
                </p>
                {data?.weather?.[0]?.description !== undefined && (
                  <div
                    className={`${styles.descriptionBackgroundColor} ${styles.cardStyle} d-flex flex-row align-items-center`}
                  >
                    <p className={styles.descriptionMargin}>
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
                )}
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}
