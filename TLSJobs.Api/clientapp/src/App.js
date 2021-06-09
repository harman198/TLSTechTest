import { useState } from "react";
import JobItem from "./components/JobItem";
import ListView from "./components/ListView";
import dummyJobs from "./fixtures/jobs.json";

function App() {
    const [listStyle, setListStyle] = useState("list");

    const buttonClickHandler = (ev) => {
        if (listStyle === "list") {
            setListStyle("grid");
        } else {
            setListStyle("list");
        }
        console.log("List Style", listStyle);
    };
    return (
        <div className="App">
            <button
                onClick={buttonClickHandler}
                style={{
                    border: "1px solid gray",
                    borderRadius: "6px",
                    padding: "6px 12px",
                    marginBottom: "40px",
                    cursor: "pointer",
                }}
            >
                Toggle List/Grid Style
            </button>
            <ListView listStyle={listStyle}>
                {dummyJobs.map((job) => (
                    <JobItem key={job.id} job={job} />
                ))}
            </ListView>
        </div>
    );
}

export default App;
