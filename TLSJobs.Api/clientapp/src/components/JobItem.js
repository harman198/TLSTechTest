import React from "react";

import "./JobItem.css";

export default function JobItem({ job }) {
    return (
        <div className="jobitem">
            <div>Job ID: {job.id}</div>
            <div>Salary: {job.salary}</div>
            <div>Title: {job.title}</div>
            <div>Description: {job.description}</div>
            <div>Added At: {job.addedat}</div>
        </div>
    );
}
