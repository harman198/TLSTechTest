import React from "react";

export default function ListView({ children, listStyle }) {
    const isListView =
        listStyle === undefined || listStyle === "" || listStyle === "list";
    return (
        <div className={"list " + isListView ? "" : "list--grid"}>
            {children}
        </div>
    );
}
