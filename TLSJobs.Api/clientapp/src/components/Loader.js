import React from "react";

import "./Loader.css";

export default function Loader({ loadingText }) {
    return (
        <div className="loader">
            <span className="loader__spinner"></span>
            <span className="loader__text">{loadingText}</span>
        </div>
    );
}
