#!/bin/bash

function usage()
{
cat << _EOT_

 creator
------------

Create unity project.

Usage:
  ./$(basename "$0") --name ui [ --base template ]

Required:
  -n, --name ui : Name of unity project.

Optional:
  -b, --base template : Name of base unity project. [ default: template ]

Helper options:
  --help, --debug

_EOT_
  [[ "${1+x}" != "" ]] && { exit "${1}"; }
  exit 1
}
function printColored() { local B="\033[0;"; local C=""; case "${1}" in "red") C="31m";; "green") C="32m";; "yellow") C="33m";; "blue") C="34m";; esac; printf "%b%b\033[0m" "${B}${C}" "${2}"; }



#------------------------------------------
# Preparation
#------------------------------------------
set -eu

# Parse parameters
for ARG in "$@"
do
    SHIFT="true"
    [[ "${ARG}" == "--debug" ]] && { shift 1; set -eux; SHIFT="false"; }
    { [[ "${ARG}" == "--name" ]] || [[ "${ARG}" == "-n" ]]; } && { shift 1; NAME="${1}"; SHIFT="false"; }
    { [[ "${ARG}" == "--base" ]] || [[ "${ARG}" == "-b" ]]; } && { shift 1; BASE="${1}"; SHIFT="false"; }
    { [[ "${ARG}" == "--help" ]] || [[ "${ARG}" == "-h" ]]; } && { shift 1; HELP="true"; SHIFT="false"; }
    { [[ "${SHIFT}" == "true" ]] && [[ "$#" -gt 0 ]]; } && { shift 1; }
done
[[ -n "${HELP+x}" ]] && { usage 0; }
# Check required parameters
[[ -z "${NAME+x}" ]] && { printColored yellow "[!] --name is required.\n"; INVALID_STATE="true"; }
# Check invalid state and display usage
[[ -n "${INVALID_STATE+x}" ]] && { usage; }
# Initialize optional variables
[[ -z "${BASE+x}" ]] && { BASE="template"; }



#------------------------------------------
# Main
#------------------------------------------

cat << __EOT__

[ Required parameters ]
name: ${NAME}

[ Optional parameters ]
base: ${BASE}

__EOT__

PROJECT_DIR="$(cd $(dirname "${BASH_SOURCE:-$0}") && pwd)"
TEMPLATE_DIR="${PROJECT_DIR}/${BASE}"
TARGET_DIR="${PROJECT_DIR}/${NAME}"
PROJECT_SETTING_PATH="${PROJECT_DIR}/${NAME}/ProjectSettings/ProjectSettings.asset"
README_PATH="${PROJECT_DIR}/${NAME}/README.md"

rsync -a "${TEMPLATE_DIR}/" "${TARGET_DIR}" \
  --exclude 'Library/' \
  --exclude 'obj/' \
  --exclude '*.csproj' \
  --exclude '*.sln' \
  --exclude '*.sln' \
  --exclude '.vs/'

PLACEHOLDER="XXXXXXXXXXXXXXX"
[[ ${BASE} != "template" ]] && { PLACEHOLDER="${BASE}" ;}
sed -i "" "s/${PLACEHOLDER}/${NAME}/g" "${PROJECT_SETTING_PATH}"
sed -i "" "s/${PLACEHOLDER}/${NAME}/g" "${README_PATH}"
