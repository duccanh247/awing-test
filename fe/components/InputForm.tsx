import React, { useEffect, useState } from "react";
import { useForm, Controller } from "react-hook-form";
import { TextField, Button } from "@mui/material";
import { useCalStore } from "@/stores/CalStore";
import API from "@/constants/api";
import { CalInput } from "@/interfaces/Calculation";

interface Props {
  reloadTable: () => void;
}

function InputForm({ reloadTable }: Props) {
  const { calParam } = useCalStore();
  const {
    handleSubmit,
    control,
    setValue,
    formState: { errors },
  } = useForm<CalInput>({ mode: "onChange", defaultValues: calParam });

  const [result, setResult] = useState<string>("");
  const [errorMsg, setErrorMsg] = useState<string>("");

  useEffect(
    function () {
      setValue("var_N", calParam.var_N);
      setValue("var_M", calParam.var_M);
      setValue("var_P", calParam.var_P);
      setValue("matrix", calParam.matrix);
    },
    [calParam]
  );

  useEffect(function () {
    console.log(setValue);
  }, []);

  const onSubmit = (data: any) => {
    const matrixInput = [];
    // validate
    const matrixRows = data.matrix.split("\n");
    if (matrixRows.length != data.var_N) {
      setErrorMsg("So row phai bang N");
      return;
    }

    for (let i = 0; i < matrixRows.length; i++) {
      const arr = matrixRows[i].trim().split(" ");
      console.log(arr);
      if (arr.length != data.var_M) {
        setErrorMsg("So Cot phai bang M: " + matrixRows[i]);
        return;
      }
      matrixInput.push(arr);
    }

    console.log("matrixInput: ", matrixInput);
    setErrorMsg("");
    data.P = data.var_P as number;
    const params = {
      P: 123,
      matrix: matrixInput, // data.matrix,
    };
    console.log(data);
    console.log(params);
    API.post(`Calculator/Calculate`, params)
      .then((res) => {
        console.log("res");
        console.log(res);
        setResult(res.data);
        reloadTable();
      })
      .catch((err) => {
        setErrorMsg(err.message);
        console.error("Request failed:", err);
      });
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div className="flex flex-row gap-5 mt-2">
        <div className=" w-1/3">
          <Controller
            name="var_N"
            control={control}
            rules={{
              required: { value: true, message: "This field is required" },
              min: { value: 1, message: "Enter number > 1" },
              max: { value: 500, message: "Enter number < 500" },
            }}
            render={({ field }) => (
              <>
                <TextField
                  {...field}
                  label="N"
                  variant="outlined"
                  placeholder="Enter a number"
                  type="number"
                  slotProps={{
                    inputLabel: {
                      shrink: true,
                    },
                  }}
                  fullWidth
                  size="small"
                  margin="normal"
                  error={!!errors.var_N}
                />
                {errors.var_N && (
                  <p className="text-red-500 text-xs">
                    {errors.var_N?.message as string}
                  </p>
                )}
              </>
            )}
          />
        </div>
        <div className=" w-1/3">
          <Controller
            name="var_M"
            control={control}
            rules={{
              required: { value: true, message: "This field is required" },
              min: { value: 1, message: "Enter number > 1" },
              max: { value: 500, message: "Enter number < 500" },
            }}
            render={({ field }) => (
              <>
                <TextField
                  {...field}
                  label="M"
                  variant="outlined"
                  placeholder="Enter a number"
                  slotProps={{
                    inputLabel: {
                      shrink: true,
                    },
                  }}
                  type="number"
                  fullWidth
                  error={!!errors.var_M}
                  size="small"
                  // helperText={errors.firstName?.message as string}
                  margin="normal"
                />
                {errors.var_M && (
                  <p className="text-red-500 text-xs">
                    {errors.var_M?.message as string}
                  </p>
                )}
              </>
            )}
          />
        </div>
        <div className=" w-1/3">
          <Controller
            name="var_P"
            control={control}
            rules={{
              required: { value: true, message: "This field is required" },
              min: { value: 1, message: "Enter number > 1" },
            }}
            render={({ field }) => (
              <>
                <TextField
                  {...field}
                  label="P"
                  variant="outlined"
                  placeholder="Enter a number"
                  slotProps={{
                    inputLabel: {
                      shrink: true,
                    },
                  }}
                  type="number"
                  fullWidth
                  size="small"
                  error={!!errors.var_P}
                  // helperText={errors.firstName?.message as string}
                  margin="normal"
                />
                {errors.var_P && (
                  <p className="text-red-500 text-xs">
                    {errors.var_P?.message as string}
                  </p>
                )}
              </>
            )}
          />
        </div>
      </div>
      <div className=" w-full mt-3 ">
        <Controller
          name="matrix"
          control={control}
          defaultValue=""
          rules={{
            required: { value: true, message: "This field is required" },
            pattern: {
              value: /^[0-9\s\n]*$/,
              message: "Chỉ được nhập số, dấu cách và dấu xuống dòng",
            },
          }}
          render={({ field }) => (
            <>
              <TextField
                {...field}
                label="Matrix number"
                variant="outlined"
                placeholder="Enter matrix number, separate by space and row \n 1 2 3 4\n 6 5 3 2 \n ..."
                multiline
                error={!!errors.matrix}
                rows="10"
                fullWidth
                size="small"
                margin="normal"
              />
              {errors.matrix && (
                <p className="text-red-500 text-xs">
                  {errors.matrix?.message as string}
                </p>
              )}
            </>
          )}
        />
      </div>
      <p className="text-red-500">{errorMsg}</p>
      <div className="flex justify-between">
        <Button type="submit" variant="contained" color="primary">
          Submit
        </Button>
        <Button variant="outlined" disabled color="success">
          Result: {result}
        </Button>
      </div>
    </form>
  );
}

export default InputForm;
