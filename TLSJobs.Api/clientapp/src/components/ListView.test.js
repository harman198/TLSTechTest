import { render, screen } from "@testing-library/react";
import React from "react";
import ListView from "./ListView";

describe("ListView", () => {
    it("Should Render 'No Rows Available' when rows passed in are empty", () => {
        render(<ListView rows={[]} />);
        const text = screen.getByText(/No Rows Available/i);
        expect(text).toBeInTheDocument();
    });
    it.todo("Should Render passed in rows As List View as default");
    it.todo(
        "Should Render passed in rows As Grid View when parameter passed in"
    );
});
