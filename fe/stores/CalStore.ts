// store/formStore.ts
import { CalInput } from '@/interfaces/Calculation';
import { create } from 'zustand';

type CalStore = {
    calParam: CalInput;
  setCalParam: (values: CalInput) => void;
};

export const useCalStore = create<CalStore>((set) => ({
    calParam: {
     var_N: 1,
     var_M: 1,
     var_P: 1,
  },
  setCalParam: (values) => set({ calParam: values }),
}));
