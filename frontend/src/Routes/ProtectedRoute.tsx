import React from "react";
import { Navigate, useLocation } from "react-router-dom";
import { useAuth } from "../Context/UseAuth";

type Props = { children: React.ReactNode };

const ProtectedRoute = ({ children }: Props) => {
  const location = useLocation();
  const { isLoggedin } = useAuth();
  return isLoggedin() ? (
    <>{children}</>
  ) : (
    <Navigate to="/login" state={{ from: location }} replace />
  );
};

export default ProtectedRoute;