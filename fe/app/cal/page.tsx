"use client";

// import HistoryCal from "@/components/HistoryCal";
import InputForm from "@/components/InputForm";
import API from "@/constants/api";
import { HistoryCal } from "@/interfaces/Calculation";
import { useCalStore } from "@/stores/CalStore";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Button,
} from "@mui/material";
import { useEffect, useState } from "react";

// const rows: HistoryCal[] = [
//   { var_N: 3, var_M: 4, var_P: 25, matrix: "john@example.com", result: 123 },
//   { var_N: 3, var_M: 3, var_P: 30, matrix: "jane@example.com", result: 44 },
//   { var_N: 2, var_M: 3, var_P: 28, matrix: "alice@example.com", result: 22 },
// ];

export default function Cal() {
  const { setCalParam } = useCalStore();
  const [calLogs, setCalLog] = useState<HistoryCal[]>([]);
  const handleRowClick = (row: HistoryCal) => {
    setCalParam(row);
    console.log("Clicked row:", row);
    // Bạn có thể điều hướng, mở modal, v.v. tại đây
  };

  useEffect(function () {
    reloadTable();
  }, []);

  const reloadTable = () => {
    API.get(`Calculator/GetLog`).then((res) => {
      console.log("res");
      console.log(res);
      setCalLog(res.data as HistoryCal[]);
    });
  };
  return (
    <>
      <div className="flex flex-row gap-5">
        <div className="w-1/2">
          <h1 className="text-xl">Enter input parameters</h1>
          <InputForm reloadTable={reloadTable}></InputForm>
        </div>
        <div className="w-1/2">
          <h1 className="text-xl text-bold">History</h1>
          <div className="mt-5">
            <TableContainer component={Paper}>
              <Table>
                <TableHead>
                  <TableRow>
                    <TableCell>
                      <strong>N</strong>
                    </TableCell>
                    <TableCell>
                      <strong>M</strong>
                    </TableCell>
                    <TableCell>
                      <strong>P</strong>
                    </TableCell>
                    <TableCell>
                      <strong>Matrix</strong>
                    </TableCell>
                    <TableCell>
                      <strong>Result</strong>
                    </TableCell>
                    <TableCell>
                      <strong>Action</strong>
                    </TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {calLogs.map((row, index) => (
                    <TableRow
                      key={index}
                      hover
                      // onClick={() => handleRowClick(row)}
                      sx={{ cursor: "pointer" }}
                    >
                      <TableCell>{row.var_N}</TableCell>
                      <TableCell>{row.var_M}</TableCell>
                      <TableCell>{row.var_P}</TableCell>
                      <TableCell>{row.matrix}</TableCell>
                      <TableCell>{row.result}</TableCell>
                      <TableCell>
                        <Button
                          onClick={() => handleRowClick(row)}
                          variant="contained"
                          color="warning"
                          size="small"
                        >
                          Re-test
                        </Button>
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          </div>
        </div>
      </div>
    </>
  );
}
