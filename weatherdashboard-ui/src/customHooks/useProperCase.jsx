import { useCallback } from "react";

function useProperCase() {
  const toProperCase = useCallback((stringData) => {
    return stringData
      ?.split(" ")
      .map((word) => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
      .join(" ");
  }, []);
  return toProperCase;
}

export default useProperCase;
