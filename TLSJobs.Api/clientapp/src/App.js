import { useState, useEffect } from "react";
import JobItem from "./components/JobItem";
import ListView from "./components/ListView";
import Loader from "./components/Loader";

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

    const [state, setState] = useState({ loading: false, jobs: [] });

    const baseURL = "/api/jobs";
    const fetchDataFromServer = () => {
        setState({ jobs: [], loading: true });
        fetch(baseURL)
            .then((response) => response.json())
            .then((data) => {
                setState({ jobs: data, loading: false });
            })
            .catch((err) => {
                console.log(err);
            });
    };

    useEffect(() => {
        fetchDataFromServer();
    }, []);

    if (state.loading) return <Loader loadingText={"Loading..."} />;

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
                {state.jobs.map((job) => (
                    <JobItem key={job.id} job={job} />
                ))}
            </ListView>
        </div>
    );
}

export default App;
