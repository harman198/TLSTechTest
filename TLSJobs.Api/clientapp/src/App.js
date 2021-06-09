import { useState, useEffect } from "react";
import JobItem from "./components/JobItem";
import ListView from "./components/ListView";

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

    const [jobs, setJobs] = useState([]);

    const baseURL = "/api/jobs";
    const fetchDataFromServer = () => {
        fetch(baseURL)
            .then((response) => response.json())
            .then((data) => {
                setJobs(data);
            })
            .catch((err) => {
                console.log(err);
            });
    };

    useEffect(() => {
        fetchDataFromServer();
    }, []);
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
                {jobs.map((job) => (
                    <JobItem key={job.id} job={job} />
                ))}
            </ListView>
        </div>
    );
}

export default App;
