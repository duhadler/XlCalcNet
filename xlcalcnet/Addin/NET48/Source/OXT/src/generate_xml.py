# XML generation for the MpFunlab LibreOffice Calc Add-in.
# Based on work by Jan Holst Jensen, see http://www.biochemfusion.com/doc/Calc_addin_howto.html

# A unique ID for the add-in.
addin_id = "com.duhadler.release.MpFunlab"
addin_version = "1.00"
addin_displayname = "MpFunLab."
addin_publisher_link = "https://github.com/duhadler"
addin_publisher_name = "D.U. Hadler"

# description.xml
#
#

desc_xml = open('description.xml', 'w')

desc_xml.write('<?xml version="1.0" encoding="UTF-8"?>\n')
desc_xml.write('<description xmlns="http://openoffice.org/extensions/description/2006" \n')
desc_xml.write('xmlns:d="http://openoffice.org/extensions/description/2006" \n')
desc_xml.write('xmlns:xlink="http://www.w3.org/1999/xlink"> \n' + '\n')
desc_xml.write('<dependencies> \n')
desc_xml.write('	<OpenOffice.org-minimal-version value="2.4" d:name="OpenOffice.org 2.4"/> \n')
desc_xml.write('</dependencies> \n')
desc_xml.write('\n')

desc_xml.write('<icon> \n')
desc_xml.write('	<default xlink:href="icons/xlcalcnet.png" /> \n')
desc_xml.write('</icon> \n')
desc_xml.write('\n')

desc_xml.write('<registration> \n')
desc_xml.write('<simple-license  accept-by="admin" default-license-id="ID0" suppress-on-update="true" > \n')
desc_xml.write('	<license-text xlink:href="registration/license.txt" lang="en" license-id="ID0"  /> \n')
desc_xml.write('</simple-license> \n')
desc_xml.write('</registration> \n')
desc_xml.write('\n')

desc_xml.write('<identifier value="' + addin_id + '" /> \n')
desc_xml.write('<version value="' + addin_version + '" />\n')   
desc_xml.write('<display-name><name lang="en">' + addin_displayname + '</name></display-name>\n')
desc_xml.write('<publisher><name xlink:href="' + addin_publisher_link + '" lang="en">' + addin_publisher_name + '</name></publisher>\n')
desc_xml.write('\n')
desc_xml.write('</description> \n')

desc_xml.close

def add_manifest_entry(xml_file, file_type, file_name):
    xml_file.write('<manifest:file-entry manifest:media-type="application/vnd.sun.star.' + file_type + '" \n')
    xml_file.write('	manifest:full-path="' + file_name + '"/> \n')

# manifest.xml
#
# List of files in package and their types.

manifest_xml = open('manifest.xml', 'w')
manifest_xml.write('<?xml version="1.0" encoding="UTF-8"?>\n')
manifest_xml.write('<manifest:manifest>\n');

add_manifest_entry(manifest_xml, 'basic-library', 'MpFunLabCore/')
add_manifest_entry(manifest_xml, 'configuration-data', 'Addons.xcu')
add_manifest_entry(manifest_xml, 'package-bundle-description;locale=en', 'pkg-desc/pkg-description.en')

add_manifest_entry(manifest_xml, 'uno-typelibrary;type=RDB', 'XMpFunlab.rdb')
add_manifest_entry(manifest_xml, 'configuration-data', 'CalcAddIn.xcu')
add_manifest_entry(manifest_xml, 'uno-component;type=Python', 'xlcalcnet.py')
manifest_xml.write('</manifest:manifest> \n')

manifest_xml.close

# CalcAddIn.xcu
#
#

# instance_id references the named UNO component instantiated by Python code.
instance_id = "com.duhadler.release.MpFunlab.python.MpFunlabImpl"
# Name of the corresponding Excel add-in if you want to share documents across LibreOffice and Excel.
excel_addin_name = "MpFunlabExample.xlam"

def define_function(xml_file, function_name, description, parameters):
    xml_file.write('  <node oor:name="' + function_name + '" oor:op="replace">\n')
    xml_file.write('    <prop oor:name="DisplayName"><value xml:lang="en">' + function_name + '</value></prop>\n')
    xml_file.write('    <prop oor:name="Description"><value xml:lang="en">' + description + '</value></prop>\n')
    xml_file.write('    <prop oor:name="Category"><value>Add-In</value></prop>\n')
    xml_file.write('    <prop oor:name="CompatibilityName"><value xml:lang="en">AutoAddIn.MpFunlab.' + function_name + '</value></prop>\n')
    xml_file.write('    <node oor:name="Parameters">\n')

    for p, desc in parameters:
        # Optional parameters will have a displayname enclosed in square brackets.
        p_name = p.strip("[]")		
        xml_file.write('      <node oor:name="' + p_name + '" oor:op="replace">\n')
        xml_file.write('        <prop oor:name="DisplayName"><value xml:lang="en">' + p_name + '</value></prop>\n')
        xml_file.write('        <prop oor:name="Description"><value xml:lang="en">' + desc + '</value></prop>\n')
        xml_file.write('      </node>\n')

    xml_file.write('    </node>\n')
    xml_file.write('  </node>\n')

#
calcaddin_xml = open('CalcAddIn.xcu', 'w')

calcaddin_xml.write('<?xml version="1.0" encoding="UTF-8"?>\n')
calcaddin_xml.write('<oor:component-data xmlns:oor="http://openoffice.org/2001/registry" xmlns:xs="http://www.w3.org/2001/XMLSchema" oor:name="CalcAddIns" oor:package="org.openoffice.Office">\n')
calcaddin_xml.write('<node oor:name="AddInInfo">\n')
calcaddin_xml.write('<node oor:name="' + instance_id + '" oor:op="replace">\n')
calcaddin_xml.write('<node oor:name="AddInFunctions">\n')



define_function(calcaddin_xml, \
    'asdouble', 'Converts the string representation of a multiple-precision number into a double.', \
    [('MpString', 'String representation of a multiple-precision number')])


define_function(calcaddin_xml, \
    'apy0', 'CPython function with no parameter', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'apy1', 'CPython function with one parameter', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'apy2', 'CPython function with two parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'apy3', 'CPython function with three parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'apy4', 'CPython function with four parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'apy5', 'CPython function with five parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Param5', 'Parameter 5, to be referenced in Python code as P5'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'apy6', 'CPython function with six parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Param5', 'Parameter 5, to be referenced in Python code as P5'), \
    ('Param6', 'Parameter 6, to be referenced in Python code as P6'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'apy7', 'CPython function with seven parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Param5', 'Parameter 5, to be referenced in Python code as P5'), \
    ('Param6', 'Parameter 6, to be referenced in Python code as P6'), \
    ('Param7', 'Parameter 7, to be referenced in Python code as P7'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'apy8', 'CPython function with eight parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Param5', 'Parameter 5, to be referenced in Python code as P5'), \
    ('Param6', 'Parameter 6, to be referenced in Python code as P6'), \
    ('Param7', 'Parameter 7, to be referenced in Python code as P7'), \
    ('Param8', 'Parameter 8, to be referenced in Python code as P8'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])


define_function(calcaddin_xml, \
    'apy9', 'CPython function with nine parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Param5', 'Parameter 5, to be referenced in Python code as P5'), \
    ('Param6', 'Parameter 6, to be referenced in Python code as P6'), \
    ('Param7', 'Parameter 7, to be referenced in Python code as P7'), \
    ('Param8', 'Parameter 8, to be referenced in Python code as P8'), \
    ('Param9', 'Parameter 9, to be referenced in Python code as P9'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])



define_function(calcaddin_xml, \
    'aspy0', 'CPython function (server) with no parameter', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'aspy1', 'CPython function (server) with one parameter', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'aspy2', 'CPython function (server) with two parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'aspy3', 'CPython function (server) with three parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'aspy4', 'CPython function (server) with four parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'aspy5', 'CPython function (server) with five parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Param5', 'Parameter 5, to be referenced in Python code as P5'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'aspy6', 'CPython function (server) with six parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Param5', 'Parameter 5, to be referenced in Python code as P5'), \
    ('Param6', 'Parameter 6, to be referenced in Python code as P6'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'aspy7', 'CPython function (server) with seven parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Param5', 'Parameter 5, to be referenced in Python code as P5'), \
    ('Param6', 'Parameter 6, to be referenced in Python code as P6'), \
    ('Param7', 'Parameter 7, to be referenced in Python code as P7'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])

define_function(calcaddin_xml, \
    'aspy8', 'CPython function (server) with eight parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Param5', 'Parameter 5, to be referenced in Python code as P5'), \
    ('Param6', 'Parameter 6, to be referenced in Python code as P6'), \
    ('Param7', 'Parameter 7, to be referenced in Python code as P7'), \
    ('Param8', 'Parameter 8, to be referenced in Python code as P8'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])


define_function(calcaddin_xml, \
    'apsy9', 'CPython function (server) with nine parameters', \
    [('Formula', 'Python code, using $n for newline and $t for indentation.'), \
    ('Param1', 'Parameter 1, to be referenced in Python code as P1'), \
    ('Param2', 'Parameter 2, to be referenced in Python code as P2'), \
    ('Param3', 'Parameter 3, to be referenced in Python code as P3'), \
    ('Param4', 'Parameter 4, to be referenced in Python code as P4'), \
    ('Param5', 'Parameter 5, to be referenced in Python code as P5'), \
    ('Param6', 'Parameter 6, to be referenced in Python code as P6'), \
    ('Param7', 'Parameter 7, to be referenced in Python code as P7'), \
    ('Param8', 'Parameter 8, to be referenced in Python code as P8'), \
    ('Param9', 'Parameter 9, to be referenced in Python code as P9'), \
    ('Transposed', 'Optional: If set to a non-zero value, the output will be transposed'), \
    ('ShowShape', 'Optional: If set to a non-zero value, the shape will be indicated in the output')])








calcaddin_xml.write('</node>\n')
calcaddin_xml.write('</node>\n')
calcaddin_xml.write('</node>\n')
calcaddin_xml.write('</oor:component-data>\n')

calcaddin_xml.close

# Done
