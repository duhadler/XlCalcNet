
import time
import pandas as pd



def main_tests(**kwargs):
    get_irisdata()


def get_documents_folder():
    """Returns the documents folder."""
    import ctypes, ctypes.wintypes
    buf = ctypes.create_unicode_buffer(ctypes.wintypes.MAX_PATH)
    ctypes.windll.shell32.SHGetFolderPathW(None, 0x0005, None, 0, buf)
    return str(buf.value)

def get_irisdata():
    fn = get_documents_folder()
    fn += r'\DataXlCalcNet\DataExamples\MainExamples\Workbooks\Datasets.xlsx'
    datasets = pd.ExcelFile(fn)
    df = pd.read_excel(datasets, 'iris')
    print(df)
    print(df.head(8))
    print(df.dtypes)



try:
    if __name__ == '__main__':
        start0 = time.time()
        main_tests()
        end0 = time.time()
        print('Elapsed time:', format(end0 - start0, '.4g'), 'seconds' )


except Exception:
    import traceback
    print(traceback.format_exc())