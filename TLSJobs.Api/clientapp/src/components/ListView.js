import React from "react";

import "./ListView.css";

export default function ListView({ children, listStyle }) {
    const isListView =
        listStyle === undefined || listStyle === "" || listStyle === "list";
    console.log(isListView);
    return (
        <div className={"list " + (isListView ? "" : "list--grid")}>
            {children}
        </div>
    );
}
